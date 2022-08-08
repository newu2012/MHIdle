import "reflect-metadata";
import { Container } from "inversify";
import TYPES from "./types";
import { Character } from "./models/character/Character";
import { ActionService } from "./services/ActionService";
import { RegionService } from "./services/RegionService";

const container = new Container();

container.bind<Character>(TYPES.Character).to(Character).inSingletonScope();
container.bind<ActionService>(TYPES.ActionService).to(ActionService).inSingletonScope();
container.bind<RegionService>(TYPES.RegionService).to(RegionService).inSingletonScope();

export default container;