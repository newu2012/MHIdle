import { CharacterEquipment } from "./CharacterEquipment";
import { Inventory } from "./Inventory";
import { CharacterStats } from "./CharacterStats";
import { injectable } from "inversify";
import { ref } from "vue";

@injectable()
export class Character {
  constructor(
    name = ref("Hunter"),
    maxHealth = ref(100),
    health = ref(maxHealth),
    maxStamina = ref(50),
    stamina = ref(maxStamina),
    equipment = ref(new CharacterEquipment()),
    currentInventory = ref(new Inventory(10, [])),
    storageInventory = ref(new Inventory(20, [])),
    stats = ref(new CharacterStats())) {
    this.name = name;
    this.maxHealth = maxHealth;
    this.health = health;
    this.maxStamina = maxStamina;
    this.stamina = stamina;
    this.equipment = equipment;
    this.currentInventory = currentInventory;
    this.storageInventory = storageInventory;
    this.stats = stats;
  }

  name;
  maxHealth;
  health;
  maxStamina;
  stamina;
  equipment;
  currentInventory;
  storageInventory;
  stats;
}