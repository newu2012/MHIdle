import "reflect-metadata";
import { Container } from "inversify";
import TYPES from "./types";
import { Character } from "./models/character/Character";
import { ActionService } from "./services/ActionService";
import { RandomService } from "./services/RandomService";
import { RegionService } from "./services/RegionService";
import { StartupLoadService } from "./services/StartupLoadService";
import { ModelsService } from "./services/ModelsService";

const container = new Container();

container.bind<ModelsService>(TYPES.ModelsService).to(ModelsService).inSingletonScope();
container.bind<StartupLoadService>(TYPES.StartupLoadService).to(StartupLoadService).inSingletonScope();
container.bind<Character>(TYPES.Character).to(Character).inSingletonScope();
container.bind<ActionService>(TYPES.ActionService).to(ActionService).inSingletonScope();
container.bind<RandomService>(TYPES.RandomService).to(RandomService).inSingletonScope();
container.bind<RegionService>(TYPES.RegionService).to(RegionService).inSingletonScope();

export default container;