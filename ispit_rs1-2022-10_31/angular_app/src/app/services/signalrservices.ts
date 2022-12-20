import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import {MojConfig} from "../moj-config";

@Injectable({
  providedIn: 'root'
})
export class SignalrFeedService {

  private hubConnection?: signalR.HubConnection
  public podaci1: any;
  public podaci2: any;

  public otvoriKanal()
  {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(MojConfig.adresa_servera + '/feedhub')
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))

    this.hubConnection.on('slanje_poruke1', (podaci) => {
      this.podaci1 = podaci;
      console.log(podaci);
    });

    this.hubConnection.on('slanje_poruke2', (podaci) => {
      this.podaci2 = podaci;
      console.log(podaci);
    });
  }


}
