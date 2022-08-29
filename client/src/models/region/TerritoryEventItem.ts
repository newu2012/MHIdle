import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { Item } from "../items/Item";
import { ref } from "vue";
import container from "../../inversify.config";
import TYPES from "../../types";
import { ModelsService } from "../../services/ModelsService";

export class TerritoryEventItem extends owp<Item> {
  constructor(
    itemName: string,
    value: number,
    minimumQuantity: number,
    maximumQuantity: number) {
    const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService)).value;
    const obj: Item = modelsService.items.filter(it => it.name === itemName)[0];

    super(obj, value);
    this.itemName = itemName;
    this.value = value;
    this.minimumQuantity = minimumQuantity;
    this.maximumQuantity = maximumQuantity;
  }

  itemName: string;
  value: number;
  minimumQuantity: number;
  maximumQuantity: number;
}