import { inject, injectable } from "inversify";
import TYPES from "../types";
import { RandomService } from "./RandomService";
import { Ref, ref, UnwrapRef } from "vue";
import container from "../inversify.config";
import { Character } from "../models/character/Character";
import { Territory } from "../models/region/Territory";
import { ModelsService } from "./ModelsService";
import { ResourceNode } from "../models/region/ResourceNode";
import { TerritoryEventItem } from "../models/region/TerritoryEventItem";
import { Instrument } from "../models/items/Instrument";
import { ActionMainService } from "./ActionMainService";

@injectable()
export class RegionService {
  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.ActionMainService) actionMainService: ActionMainService,
    @inject(TYPES.Character) character: Character,
  ) {
    this.modelsService = modelsService;
    this.actionMainService = actionMainService;
    this.character = character;
  }

  modelsService: ModelsService;
  actionMainService: ActionMainService;
  character: Character;
  activeTerritory: Territory;
  activeEvent?: Ref<UnwrapRef<ResourceNode>>;
  activeEventCapacity: number;

  ChangeTerritory(territory: Territory) {
    //  TODO Change to notification
    console.log(`You moved from ${this.activeTerritory.name} to ${territory.name}`);
    this.actionMainService.RestartActionTimer();
    this.activeTerritory = territory;
    this.activeEvent = undefined;

    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;
    if (this.activeTerritory.territoryEvents.length > 0) {
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.explore());
    } else {
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.idle());
    }
  }

  AutoExplore() {
    //  TODO Move out duration time and its calculation to some stats class
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;
    actionMainService.SetCurrentAction(this.actionMainService.availableActions.explore());
  }

  Explore() {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;

    //  TODO Change from ResourceNode to owp<any> ???
    regionService.activeEvent =
      randomService.GetRandFromProportion(regionService.activeTerritory.territoryEvents).obj;
    regionService.activeEventCapacity = regionService.activeEvent?.capacity ?? 0;
    //  TODO Change to notification
    console.log(`Found ${regionService.activeEvent?.name}`);

    if (regionService.activeEvent?.type === "Monster") {
      //  TODO set hunting as current action
      //   actionService.SetCurrentAction(this.actionService.availableActions.hunt());
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.hunt());
    } else {
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.gather());
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
    const actionMainService = ref(container.get<ActionMainService>(TYPES.ActionMainService)).value;

    if (regionService.activeEvent === undefined) {
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.explore());
      return;
    }

    const randomResource = randomService
      .GetRandFromProportion(regionService.activeEvent.obj) as TerritoryEventItem;
    const amount = randomService
      .GetRandIntBetween({
        from: randomResource.minimumQuantity,
        to: randomResource.maximumQuantity,
      });

    character.currentInventory.AddItem(randomResource.obj, amount);
    character.currencies.researchPoints += amount * randomResource.obj.value;

    regionService.activeEventCapacity--;

    if (regionService.activeEventCapacity < 1) {
      actionMainService.SetCurrentAction(this.actionMainService.availableActions.explore());
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