import {Component, DefineComponent} from "vue";

export class Feature {
    constructor(name: string, active: boolean, componentPanel: Component) {
        this.name = name;
        this.active = active;
        this.componentPanel = componentPanel;
    }

    name: string;
    active: boolean;
    componentPanel: Component;
}