import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IStat } from './models/stat';
import { StatsParams } from './models/stats.params';
import { StatsService } from './stats.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;

  public stats: IStat[];
  public statsParams: StatsParams;
  public totalCount: number;

  public sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Rushing Yards', value: 'try' },
    { name: 'Longest Rush', value: 'lr' },
    { name: 'Rushing Touchdowns', value: 'trt' },
  ];

  constructor(private statsService: StatsService) {
    this.statsParams = this.statsService.getStatsParams();
  }

  ngOnInit(): void {
    this.getStats(true);
  }

  public getStats(newRequest: boolean) {
    this.statsService.getStats(newRequest).subscribe(
      (response) => {
        this.stats = response.data;
        this.totalCount = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  public onSortSelected(event: EventTarget) {
    const params = this.statsService.getStatsParams();

    params.sort = (<HTMLSelectElement>event).value;
    params.pageNumber = 1;

    this.statsService.setStatsParams(params);
    this.getStats(true);
  }

  public onPageChanged(event: any) {
    const params = this.statsService.getStatsParams();

    if (params.pageNumber !== event) {
      params.pageNumber = event;

      var newRequest = params.pageNumber == 1;

      this.statsService.setStatsParams(params);
      this.getStats(newRequest);
    }
  }

  public onSearch() {
    const params = this.statsService.getStatsParams();

    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;

    this.statsService.setStatsParams(params);
    this.getStats(true);
  }

  public onReset() {
    this.searchTerm.nativeElement.value = '';
    this.statsParams = new StatsParams();
    this.statsService.setStatsParams(this.statsParams);

    this.getStats(true);
  }

  public exportToCsv() {
    this.statsService.exportToCsv(this.stats, 'stats', [
      'Player',
      'Team',
      'Pos',
      'Att/G',
      'Att',
      'Yds',
      'Avg',
      'Yds/G',
      'TD',
      'Lng',
      'Lng/T',
      '1st',
      '1st%',
      '20+',
      '40+',
      'FUM',
    ]);
  }
}
