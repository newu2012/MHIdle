import { ObjectWithProportion as owp } from "../ObjectWithProportion";
import { Item } from "../items/Item";
import { ref } from "vue";
import container from "../../inversify.config";
import TYPES from "../../types";
import { ModelsService } from "../../services/ModelsService";

export class ResourceNodeItem extends owp<Item> {
  constructor(
    itemId: number,
    value: number,
    minimumQuantity: number,
    maximumQuantity: number) {
    const modelsService = ref(container.get<ModelsService>(TYPES.ModelsService)).value;
    const obj: Item = modelsService.items.filter(it => it.id === itemId)[0];

    super(obj, value);
    this.itemId = itemId;
    this.value = value;
    this.minimumQuantity = minimumQuantity;
    this.maximumQuantity = maximumQuantity;
  }

  itemId: number;
  value: number;
  minimumQuantity: number;
  maximumQuantity: number;
}