export interface IStat {
  playerName: string;
  playerTeam: string;
  playerPosition: string;
  rushingAttemps: number;
  rushingAttempsPerGameAverage: number;
  rushingAverageYardsPerAttempt: number;
  rushingYardsPerGame: number;
  totalRushingTouchdowns: number;
  totalRushingYards: number;
  longestRush: number;
  rushingFirstDowns: number;
  rushingFirstDownsPercent: number;
  rushing20Yards: number;
  rushing40Yards: number;
  rushingFumbles: number;
  longestRushTouchdown: boolean;
}
