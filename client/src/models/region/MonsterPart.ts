export class MonsterPart {
  constructor(partName: string, partType: string, maximumHealth: number, currentHealth: number) {
    this.partName = partName;
    this.partType = partType;
    this.maximumHealth = maximumHealth;
    this.currentHealth = currentHealth;
  }

  partName: string;
  partType: string;
  maximumHealth: number;
  currentHealth: number;
}