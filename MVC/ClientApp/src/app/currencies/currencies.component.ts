import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-currencies-component',
  templateUrl: './currencies.component.html'
})

export class CurrenciesComponent {

  public currencies: Currencies[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Currencies[]>(baseUrl + 'currency').subscribe(result => {
      this.currencies = result;
    }, error => console.error(error));
  }
}

interface Currencies {
  name: string;
  price: number;
}
