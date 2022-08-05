export interface Item {
  id: number;
  name: string;
  description?: string;
  maximumInStack: number;
  value: number;
}