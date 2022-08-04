import {ItemStack} from "../items/ItemStack";

export class Inventory {
    constructor(
        stacksQuantity: number = 10,
        itemStacks: ItemStack[]) {
        this.stacksQuantity = stacksQuantity;

        if (Array.isArray(itemStacks) && itemStacks.length) {
            this.itemStacks = itemStacks;
        } else {
            this.itemStacks = [];
            for (let i = 0; i < stacksQuantity; i++) {
                this.itemStacks.push(new ItemStack(undefined, 0));
            }
        }
    }

    stacksQuantity: number;
    itemStacks: ItemStack[];
}