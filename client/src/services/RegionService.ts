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

@injectable()
export class RegionService {
  modelsService: ModelsService;
  actionService: ActionService;
  character: Character;
  activeTerritory: Territory;
  inCity = ref(true);
  currentEvent?: Ref<UnwrapRef<ResourceNode>>;
  currentEventCapacity: number;

  constructor(
    @inject(TYPES.ModelsService) modelsService: ModelsService,
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character,
  ) {
    this.modelsService = modelsService;
    this.actionService = actionService;
    this.character = character;
  }

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
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    actionService.SetCurrentAction(this.actionService.availableActions.explore(
      regionService.activeTerritory.durationExploreOnEnter));
  }

  AutoExplore() {
    //  TODO Move out duration time and it calculation to some stats class
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    actionService.SetCurrentAction(this.actionService.availableActions.explore(
      regionService.activeTerritory.durationExploreInTerritory));
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

    actionService.SetCurrentAction(this.actionService.availableActions.gather(regionService.currentEvent?.duration ?? 3 * 1000));
  }

  Gather() {
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;

    if (regionService.currentEvent === undefined) {
      const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
      actionService.SetCurrentAction(this.actionService.availableActions.explore(
        regionService.activeTerritory.durationExploreInTerritory,
      ));
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
      actionService.SetCurrentAction(this.actionService.availableActions.explore(
        regionService.activeTerritory.durationExploreInTerritory,
      ));
    }
  }
}