import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service';
import { HttpClient } from '@angular/common/http';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, BaseChartDirective, Label } from 'ng2-charts';
// import * as pluginAnnotations from 'chartjs-plugin-annotation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  constructor(private signalRService: SignalRService, private http: HttpClient){}
  
  ////////////////////////////////////////////////////////////////////////////////
  public chartOptions: any = {
    scaleShowVerticalLines: true,
    responsive: true,
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    }
  };
  public chartLabels: string[] = ['Real time data for the chart'];
  public chartType: string = 'bar';
  public chartLegend: boolean = true;
  public colors: any[] = [{ backgroundColor: '#5491DA' }, { backgroundColor: '#E74C3C' }, { backgroundColor: '#82E0AA' }, { backgroundColor: '#E5E7E9' }]
 

  ////////////////////////////////////////////////////////////////////////
  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.recieveChartDataListener();
    //this.startHttpRequest();
  }

  private startHttpRequest(){ // don't use this for invocation 
    this.http.get('https://localhost:5001/api/chart').subscribe(data => {
      console.log('HttpRequest:',data); // no data here, data is null as this endpoint will not return any data
    });
  }


}
