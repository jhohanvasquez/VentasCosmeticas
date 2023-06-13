import { DetalleVenta } from "./detalle-venta";

export interface Venta {
  idVenta?: number,
  numeroDocumento?: string,
  color?: string,
  fechaRegistro?: string,
  tipoPago?: string,
  totalTexto?: string,
  detalleVenta?:DetalleVenta[]
}
