export class MonsterPart {
  constructor(partName: string, partType: string, maximumHealth: number, startingHealth: number) {
    this.partName = partName;
    this.partType = partType;
    this.maximumHealth = maximumHealth;
    this.startingHealth = startingHealth;
  }

  partName: string;
  partType: string;
  maximumHealth: number;
  startingHealth: number;
}