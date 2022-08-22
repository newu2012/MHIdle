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
    console.log(`You moved from ${this.activeTerritory.name} to ${territory.name}`);
    this.actionService.RestartActionTimer();
    this.activeTerritory = territory;

    this.inCity.value = this.modelsService.regions
      .filter(r => r.name === "City")[0].territories
      .filter(t => t.name === this.activeTerritory.name).length === 1;
    this.currentEvent = undefined;

    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    //  Takes more time for first exploring of territory
    actionService.SetCurrentAction(this.actionService.availableActions.explore(10 * 1000));
  }

  //  TODO Rework
  AutoExplore() {
    //  TODO Move out duration time and it calculation to some stats class
    //  TODO NEW Get duration from activeTerritory this.activeTerritory.exploreDuration
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;
    //  Takes more time for first exploring of territory
    actionService.SetCurrentAction(this.actionService.availableActions.explore(10 * 1000));
  }

  Explore() {
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;

    //  TODO Change from ResourceNode to owp<any> ???
    regionService.currentEvent =
      randomService.GetRandFromProportion(regionService.activeTerritory.territoryEvents);
    regionService.currentEventCapacity = regionService.currentEvent?.capacity ?? 0;

    actionService.SetCurrentAction(this.actionService.availableActions.gather(3 * 1000));
  }

  //  TODO Change to Gather (Action - Gathering)
  Gather() {
    const character = ref(container.get<Character>(TYPES.Character)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;
    const actionService = ref(container.get<ActionService>(TYPES.ActionService)).value;

    if (regionService.currentEvent === undefined) {
      actionService.SetCurrentAction(this.actionService.availableActions.explore(3 * 1000));
      return;
    }
    const randomResource = randomService.GetRandFromProportion(regionService.currentEvent.obj);
    const amount = randomService.GetRandIntBetween({ from: 0, to: 3 });

    character.currentInventory.AddItem(randomResource, amount);
    character.currencies.researchPoints += amount * randomResource.value;

    if (regionService.currentEventCapacity > 1) {
      regionService.currentEventCapacity--;
    } else {
      actionService.SetCurrentAction(this.actionService.availableActions.explore(3 * 1000));
    }
  }
}