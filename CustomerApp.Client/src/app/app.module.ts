import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import { CustomerServiceService } from './customer-service.service';
import { CustomerCreateComponent } from './customer-create/customer-create.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerDetailComponent,
    CustomerListComponent,
    PageNotFoundComponent,
    CustomerCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    InMemoryWebApiModule.forRoot(InMemoryDataService)
  ],
  providers: [CustomerServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
