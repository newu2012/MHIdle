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
  inCity = ref(true);
  currentEvent?: Ref<UnwrapRef<ResourceNode>>;
  currentEventCapacity: number;

  ChangeTerritory(territory: Territory) {
    //  TODO Change to notification
    console.log(`You moved from ${this.activeTerritory.name} to ${territory.name}`);
    this.actionService.RestartActionTimer();
    this.activeTerritory = territory;

    this.inCity.value = this.modelsService.regions
      .filter(r => r.name === "City")[0].territories
      .filter(t => t.name === this.activeTerritory.name).length === 1;
    this.currentEvent = undefined;

    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    actionService.SetCurrentAction(this.actionService.availableActions.explore());
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
    regionService.currentEvent =
      randomService.GetRandFromProportion(regionService.activeTerritory.territoryEvents).obj;
    regionService.currentEventCapacity = regionService.currentEvent?.capacity ?? 0;
    //  TODO Change to notification
    console.log(`Found ${regionService.currentEvent?.name}`);

    actionService.SetCurrentAction(this.actionService.availableActions.gather());
  }

  GetExploreDuration(): number {
    if (this.activeTerritory === undefined) {
      return -1;
    }

    let duration = this.currentEvent === undefined ?
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

    if (regionService.currentEvent === undefined) {
      actionService.SetCurrentAction(this.actionService.availableActions.explore());
      return;
    }

    const randomResource = randomService
      .GetRandFromProportion(regionService.currentEvent.obj) as ResourceNodeItem;
    const amount = randomService
      .GetRandIntBetween({
        from: randomResource.minimumQuantity,
        to: randomResource.maximumQuantity,
      });

    character.currentInventory.AddItem(randomResource.obj, amount);
    character.currencies.researchPoints += amount * randomResource.obj.value;

    if (regionService.currentEventCapacity > 1) {
      regionService.currentEventCapacity--;
    } else {
      actionService.SetCurrentAction(this.actionService.availableActions.explore());
    }
  }

  GetGatherDuration(): number {
    if (this.currentEvent === undefined) {
      return -1;
    }

    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const character = ref(container.get<Character>(TYPES.Character)).value;
    let duration = regionService.currentEvent?.duration!;
    const maximumInstrument = character.storageInventory
      .GetBestInstrumentOfType(regionService.currentEvent?.instrumentType!);

    const maximumInstrumentLevel = maximumInstrument === undefined ?
      0 :
      (maximumInstrument.item as Instrument).instrumentLevel;
    const resultLevel = regionService.currentEvent?.instrumentExpectedLevel! - maximumInstrumentLevel;
    const timeModifier = (resultLevel < 0 ?
      1 / Math.pow(2, -resultLevel) :
      Math.pow(4, resultLevel));
    duration = duration * timeModifier;

    return duration;
  }
}