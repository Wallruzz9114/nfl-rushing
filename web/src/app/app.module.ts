import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';

@NgModule({
  declarations: [AppComponent, PaginationHeaderComponent],
  imports: [BrowserModule, AppRoutingModule, NgbModule, HttpClientModule, NgxPaginationModule],
  providers: [],
  exports: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
