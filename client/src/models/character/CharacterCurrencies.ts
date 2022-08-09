export class CharacterCurrencies {
  constructor(zenny: number = 0, researchPoints: number = 0) {
    this.zenny = zenny;
    this.researchPoints = researchPoints;
  }

  zenny: number;
  researchPoints: number;
  numberFormatter = new Intl.NumberFormat();

  get zennyFormatted() {
    return this.numberFormatter.format(this.zenny);
  }

  get researchPointsFormatted() {
    return this.numberFormatter.format(this.researchPoints);
  }
}