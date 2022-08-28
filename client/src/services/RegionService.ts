import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { RandomService } from "./RandomService";
import { Ref, ref, UnwrapRef } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import { Territory } from "../models/region/Territory";
import { ModelsService } from "./ModelsService";
import { ResourceNode } from "../models/region/ResourceNode";
import { ResourceNodeItem } from "../models/region/ResourceNodeItem";
import { Instrument } from "../models/items/Instrument";

@injectable()
export class RegionService {
  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character,
  ) {
    this.modelsService = modelsService;
    this.actionService = actionService;
    this.character = character;
  }

  modelsService: ModelsService;
  actionService: ActionService;
  character: Character;
  activeTerritory: Territory;
  activeEvent?: Ref<UnwrapRef<ResourceNode>>;
  activeEventCapacity: number;

  ChangeTerritory(territory: Territory) {
    //  TODO Change to notification
    console.log(`You moved from ${this.activeTerritory.name} to ${territory.name}`);
    this.actionService.RestartActionTimer();
    this.activeTerritory = territory;
    this.activeEvent = undefined;

    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    if (this.activeTerritory.territoryEvents.length > 0) {
      actionService.SetCurrentAction(this.actionService.availableActions.explore());
    } else {
      actionService.SetCurrentAction(this.actionService.availableActions.idle());
    }
  }

  AutoExplore() {
    //  TODO Move out duration time and its calculation to some stats class
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    actionService.SetCurrentAction(this.actionService.availableActions.explore());
  }

  Explore() {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;

    //  TODO Change from ResourceNode to owp<any> ???
    regionService.activeEvent =
      randomService.GetRandFromProportion(regionService.activeTerritory.territoryEvents).obj;
    regionService.activeEventCapacity = regionService.activeEvent?.capacity ?? 0;
    //  TODO Change to notification
    console.log(`Found ${regionService.activeEvent?.name}`);

    if (regionService.activeEvent?.type === "Monster") {
      //  TODO set hunting as current action
      //   actionService.SetCurrentAction(this.actionService.availableActions.hunt());
      actionService.SetCurrentAction(this.actionService.availableActions.gather());
    } else {
      actionService.SetCurrentAction(this.actionService.availableActions.gather());
    }
  }

  GetExploreDuration(): number {
    if (this.activeTerritory === undefined) {
      return -1;
    }

    let duration = this.activeEvent === undefined ?
      this.activeTerritory.durationExploreOnEnter :
      this.activeTerritory.durationExploreInTerritory;
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const maximumInstrument = character.storageInventory
      .GetBestInstrumentOfType(this.activeTerritory.instrumentType);

    const maximumInstrumentLevel = maximumInstrument === undefined ?
      0 :
      (maximumInstrument.item as Instrument).instrumentLevel;
    const resultLevel = this.activeTerritory.instrumentExpectedLevel - maximumInstrumentLevel;
    const timeModifier = (resultLevel < 0 ?
      1 / Math.pow(2, -resultLevel) :
      Math.pow(4, resultLevel));
    duration = duration * timeModifier;

    return duration;
  }

  Gather() {
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;

    if (regionService.activeEvent === undefined) {
      actionService.SetCurrentAction(this.actionService.availableActions.explore());
      return;
    }

    const randomResource = randomService
      .GetRandFromProportion(regionService.activeEvent.obj) as ResourceNodeItem;
    const amount = randomService
      .GetRandIntBetween({
        from: randomResource.minimumQuantity,
        to: randomResource.maximumQuantity,
      });

    character.currentInventory.AddItem(randomResource.obj, amount);
    character.currencies.researchPoints += amount * randomResource.obj.value;

    if (regionService.activeEventCapacity > 1) {
      regionService.activeEventCapacity--;
    } else {
      actionService.SetCurrentAction(this.actionService.availableActions.explore());
    }
  }

  GetGatherDuration(): number {
    if (this.activeEvent === undefined) {
      return -1;
    }

    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const character = ref(container.get<Character>(TYPES.Character)).value;
    let duration = regionService.activeEvent?.duration!;
    const maximumInstrument = character.storageInventory
      .GetBestInstrumentOfType(regionService.activeEvent?.instrumentType!);

    const maximumInstrumentLevel = maximumInstrument === undefined ?
      0 :
      (maximumInstrument.item as Instrument).instrumentLevel;
    const resultLevel = regionService.activeEvent?.instrumentExpectedLevel! - maximumInstrumentLevel;
    const timeModifier = (resultLevel < 0 ?
      1 / Math.pow(2, -resultLevel) :
      Math.pow(4, resultLevel));
    duration = duration * timeModifier;

    return duration;
  }
}