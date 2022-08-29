import { CraftService } from "./services/CraftService";
import { ActionMainService } from "./services/ActionMainService";

const TYPES = {
  ModelsService: Symbol("ModelsService"),
  StartupLoadService: Symbol("StartupLoadService"),
  Character: Symbol("Character"),
  ActionMainService: Symbol("ActionMainService"),
  ActionHuntCharacterService: Symbol("ActionHuntCharacterService"),
  RandomService: Symbol("RandomService"),
  RegionService: Symbol("RegionService"),
  CraftService: Symbol("CraftService"),
  HuntService: Symbol("HuntService"),
};

export default TYPES