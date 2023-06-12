import { Component, OnInit } from '@angular/core';

import { Chart, registerables } from 'node_modules/chart.js';
import { DashboardService } from '../../../services/dashboard.service';
Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  totalProductos: string = "0";

  constructor(
    private _dashboardServicio: DashboardService,
  ) {


  }

  ngOnInit(): void {

    this._dashboardServicio.resumen().subscribe({
      next: (data) => {
        if (data.status) {

          this.totalProductos = data.value.totalProductos;

          const arrayData: any[] = data.value.ventasUltimaSemana;
        }
      },
      error: (e) => { },
      complete: () => { }
    })

  }
}
