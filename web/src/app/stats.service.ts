import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as FileSaver from 'file-saver';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagination, Pagination } from './models/pagination';
import { IStat } from './models/stat';
import { StatsParams } from './models/stats.params';

const CSV_EXTENSION = '.csv';
const CSV_TYPE = 'text/plain;charset=utf-8';

@Injectable({
  providedIn: 'root',
})
export class StatsService {
  public stats: IStat[] = [];
  public pagination = new Pagination();
  public statsParams = new StatsParams();
  public requestURL = 'http://localhost:5000/RushingStats';

  constructor(private http: HttpClient) {}

  public getStats(newRequest: boolean) {
    if (!newRequest && this.stats.length > 0) {
      const pagesReceived = Math.ceil(this.stats.length / this.statsParams.pageSize);

      if (this.statsParams.pageNumber <= pagesReceived) {
        this.pagination.data = this.stats.slice(
          (this.statsParams.pageNumber - 1) * this.statsParams.pageSize,
          this.statsParams.pageNumber * this.statsParams.pageSize
        );

        return of(this.pagination);
      }
    }

    let params = this.getCleanParams();

    return this.http
      .get<IPagination>(this.requestURL + '/GetAll', { observe: 'response', params })
      .pipe(
        map((response) => {
          if (response.body?.data) {
            this.stats = [...response.body.data];
            this.pagination = response.body;
          }

          return this.pagination;
        })
      );
  }

  public getStatsParams() {
    return this.statsParams;
  }

  public setStatsParams(params: StatsParams) {
    this.statsParams = params;
  }

  public getCleanParams() {
    let params = new HttpParams();

    if (this.statsParams.search) {
      params = params.append('search', this.statsParams.search);
    }

    params = params.append('sort', this.statsParams.sort);
    params = params.append('pageIndex', this.statsParams.pageNumber.toString());
    params = params.append('pageSize', this.statsParams.pageSize.toString());

    return params;
  }

  /**
   * Saves the file on client's machine via FileSaver library.
   *
   * @param buffer The data that need to be saved.
   * @param fileName File name to save as.
   * @param fileType File type to save as.
   */
  private saveAsFile(buffer: any, fileName: string, fileType: string): void {
    const data: Blob = new Blob([buffer], { type: fileType });
    FileSaver.saveAs(data, fileName);
  }

  /**
   * Creates an array of data to csv. It will automatically generate title row based on object keys.
   *
   * @param rows array of data to be converted to CSV.
   * @param fileName filename to save as.
   * @param columns array of object properties to convert to CSV
   */
  public exportToCsv(rows: IStat[], fileName: string, columns?: string[]) {
    if (!rows || !rows.length) {
      return;
    }

    const keys = columns;
    const headers = keys?.toString() + '\n';

    const allRows = rows
      .map((row) => {
        return `${row.playerName},${row.playerTeam},${row.playerPosition},${row.rushingAttempsPerGameAverage},${row.rushingAttemps},${row.totalRushingYards},${row.rushingAverageYardsPerAttempt},${row.rushingYardsPerGame},${row.totalRushingTouchdowns},${row.longestRush},${row.longestRushTouchdown},${row.rushingFirstDowns},${row.rushingFirstDownsPercent},${row.rushing20Yards},${row.rushing40Yards},${row.rushingFumbles}`;
      })
      .join('\n');

    const csvContent = headers + allRows;

    this.saveAsFile(csvContent, `${fileName}${CSV_EXTENSION}`, CSV_TYPE);
  }
}
