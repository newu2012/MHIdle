import { CharacterEquipment } from "./CharacterEquipment";
import { Inventory } from "./Inventory";
import { CharacterStats } from "./CharacterStats";

export class Character {
  constructor(
    name: string = "Hunter",
    maxHealth: number = 100,
    health: number = maxHealth,
    maxStamina: number = 50,
    stamina: number = maxStamina,
    equipment: CharacterEquipment = new CharacterEquipment(),
    currentInventory: Inventory = new Inventory(10, []),
    storageInventory: Inventory = new Inventory(20, []),
    stats: CharacterStats = new CharacterStats()) {
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

  name: string;
  maxHealth: number;
  health: number;
  maxStamina: number;
  stamina: number;
  equipment: CharacterEquipment;
  currentInventory: Inventory;
  storageInventory: Inventory;
  stats: CharacterStats;
}