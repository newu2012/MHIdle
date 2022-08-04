import {Equipment} from "./Equipment";

export class Weapon implements Equipment {
    name: string;
    description: string;
    id: number;
    maximumInStack: number;
    value: number;
}