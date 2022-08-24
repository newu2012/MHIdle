import { CraftService } from "./services/CraftService";

const TYPES = {
  ModelsService: Symbol("ModelsService"),
  StartupLoadService: Symbol("StartupLoadService"),
  Character: Symbol("Character"),
  ActionService: Symbol("ActionService"),
  RandomService: Symbol("RandomService"),
  RegionService: Symbol("RegionService"),
  CraftService: Symbol("CraftService"),
};

export default TYPES