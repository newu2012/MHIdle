import "reflect-metadata";
import { Container } from "inversify";
import TYPES from "./types";
import { Character } from "./models/character/Character";
import { RandomService } from "./services/RandomService";
import { RegionService } from "./services/RegionService";
import { StartupLoadService } from "./services/StartupLoadService";
import { ModelsService } from "./services/ModelsService";
import { CraftService } from "./services/CraftService";
import { HuntService } from "./services/HuntService";
import { ActionMainService } from "./services/ActionMainService";
import { ActionHuntCharacterService } from "./services/ActionHuntCharacterService";

const container = new Container();

container.bind<ModelsService>(TYPES.ModelsService).to(ModelsService).inSingletonScope();
container.bind<StartupLoadService>(TYPES.StartupLoadService).to(StartupLoadService).inSingletonScope();
container.bind<Character>(TYPES.Character).to(Character).inSingletonScope();
container.bind<ActionMainService>(TYPES.ActionMainService).to(ActionMainService).inSingletonScope();
container.bind<ActionHuntCharacterService>(TYPES.ActionHuntCharacterService).to(ActionHuntCharacterService).inSingletonScope();
container.bind<RandomService>(TYPES.RandomService).to(RandomService).inSingletonScope();
container.bind<RegionService>(TYPES.RegionService).to(RegionService).inSingletonScope();
container.bind<CraftService>(TYPES.CraftService).to(CraftService).inSingletonScope();
container.bind<HuntService>(TYPES.HuntService).to(HuntService).inSingletonScope();

export default container;