import { inject, injectable } from "inversify";
import TYPES from "../types";
import { ActionService } from "./ActionService";
import { RandomService } from "./RandomService";
import { ref } from "vue";
import container from "../inversify.config";
import { Action } from "../models/Action";
import { Character } from "../models/character/Character";
import { Territory } from "../models/region/Territory";
import { ModelsService } from "./ModelsService";
import { ResourceNode } from "../models/region/ResourceNode";

@injectable()
export class RegionService {
  actionService: ActionService;
  character: Character;
  activeTerritory: Territory;

  constructor(
    @inject(TYPES.ActionService) actionService: ActionService,
    @inject(TYPES.Character) character: Character,
  ) {
    this.actionService = actionService;
    this.character = character;
  }

  ChangeTerritory(territory: Territory) {
    console.log(`You moved from ${this.activeTerritory.name} to ${territory.name}`);
    this.actionService.RestartActionTimer();
    this.activeTerritory = territory;
  }

  AutoExplore() {
    //  TODO Move out duration time and it calculation to some stats class
    this.actionService.SetCurrentAction(new Action(
      "Exploring",
      3 * 1000,
      this.Explore, this.character));
  }

  Explore(...args: any[]) {
    const character = args[0][0];
    const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService)).value;
    const regionService = ref(container.get<RegionService>(TYPES.RegionService)).value;
    const randomService = ref(container.get<RandomService>(TYPES.RandomService)).value;

    //  TODO Change from ResourceNode to owp<any> ???
    const randomEvent: ResourceNode = randomService.GetRandFromProportion(
      regionService.activeTerritory.territoryEvents);
    const randomResource = randomService.GetRandFromProportion(randomEvent.obj);
    const amount = randomService.GetRandIntBetween({ from: 0, to: 3 });

    character.currentInventory.AddItem(randomResource, amount);
    character.currencies.researchPoints += amount * randomResource.value;
  }
}