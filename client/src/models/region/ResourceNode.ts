import { Resource } from "../items/Resource";
import { ObjectWithProportion as owp  } from "../ObjectWithProportion";

export class ResourceNode extends owp<owp<Resource>[]> {
  declare obj: owp<Resource>[];
}