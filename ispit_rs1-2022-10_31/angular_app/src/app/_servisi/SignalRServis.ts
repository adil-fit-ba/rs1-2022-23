import {Injectable} from "@angular/core";
import {MojConfig} from "../moj-config";
import * as signalR from "@microsoft/signalr"
import {HubConnection} from "@microsoft/signalr";

@Injectable({
  providedIn: "root"
})
export class SignalRServis{

  public podaci:string;
  private hubConnection: signalR.HubConnection;

  public otvoriKanalWS()
  {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(MojConfig.adresa_servera + '/TrenutnoVrijemePutanja')
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('WS konekcija pokrenuta'))
      .catch(err => console.log('WS konekcija greska: ' + err))

    this.hubConnection.on('slanje_poruke1', (podaci) => {
      this.podaci= podaci;
      console.log(podaci);
    });

    this.hubConnection.on('slanje_poruke2', (podaci) => {
      this.podaci = podaci;
      console.log(podaci);
    });
  }
}
