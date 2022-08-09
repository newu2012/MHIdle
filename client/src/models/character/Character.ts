import { injectable } from "inversify";
import { ref } from "vue";
import { CharacterEquipment } from "./CharacterEquipment";
import { CharacterStats } from "./CharacterStats";
import { CharacterCurrencies } from "./CharacterCurrencies";
import { CurrentInventory } from "./CurrentInventory";
import { StorageInventory } from "./StorageInventory";

@injectable()
export class Character {
  constructor(
    name = ref("Hunter"),
    maxHealth = ref(100),
    health = ref(maxHealth),
    maxStamina = ref(50),
    stamina = ref(maxStamina),
    equipment = ref(new CharacterEquipment()),
    currentInventory = ref(new CurrentInventory(10)),
    storageInventory = ref(new StorageInventory(20)),
    stats = ref(new CharacterStats()),
    currencies = ref(new CharacterCurrencies())) {
    this.name = name;
    this.maxHealth = maxHealth;
    this.health = health;
    this.maxStamina = maxStamina;
    this.stamina = stamina;
    this.equipment = equipment;
    this.currentInventory = currentInventory;
    this.storageInventory = storageInventory;
    this.stats = stats;
    this.currencies = currencies;
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
  currencies;
}