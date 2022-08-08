import { Armor } from "../items/Armor";
import { Weapon } from "../items/Weapon";

export class CharacterEquipment {
  constructor(
    helm?: Armor,
    chest?: Armor,
    arms?: Armor,
    waist?: Armor,
    legs?: Armor,
    weapon?: Weapon) {
    this.helm = helm;
    this.chest = chest;
    this.arms = arms;
    this.waist = waist;
    this.legs = legs;
    this.weapon = weapon;
  }

  helm?: Armor;
  chest?: Armor;
  arms?: Armor;
  waist?: Armor;
  legs?: Armor;
  //  TODO Add charms?
  weapon?: Weapon;

}