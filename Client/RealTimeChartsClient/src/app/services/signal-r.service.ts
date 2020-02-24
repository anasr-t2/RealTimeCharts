import { Injectable } from '@angular/core';
import { ChartModel } from '../Models/ChartModel';
import * as signalR from '@microsoft/signalr'

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public data: ChartModel[];

  private hubConnection: signalR.HubConnection;

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder().withUrl('https://localhost:5001/chart').build();
    // this.hubConnection = new signalR.HubConnectionBuilder().withUrl('http://localhost:64908').build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  
  public recieveChartDataListener() {
    this.hubConnection.on('recieveChartData',(data) => {
      console.log('recieveChartDataListener:',data);
      this.data = data;
    });
    this.hubConnection.on('NewOrder',(res => {
      console.log(res)
    }))
  }
}
