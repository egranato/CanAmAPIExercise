export interface IForecast {
  properties: IProperties;
}

export interface IProperties {
  gridId: string;
  gridX: string;
  gridY: string;
  temperature: ITemperature;
  maxTemperature: IMaxTemperature;
  minTemperature: IMinTemperature;
}

export interface ITemperature {
  uom: string;
  values: IValue[];
}
export interface IMaxTemperature {
  uom: string;
  values: IValue[];
}

export interface IMinTemperature {
  uom: string;
  values: IValue[];
}

export interface IValue {
  validTime: string;
  value: number;
}
