export class CharacterCurrencies {
  constructor(money: number = 0, researchPoints: number = 0) {
    this.money = money;
    this.researchPoints = researchPoints;
  }

  money: number;
  researchPoints: number;
  numberFormatter = new Intl.NumberFormat();

  get moneyFormatted() {
    return this.numberFormatter.format(this.money);
  }

  get researchPointsFormatted() {
    return this.numberFormatter.format(this.researchPoints);
  }
}