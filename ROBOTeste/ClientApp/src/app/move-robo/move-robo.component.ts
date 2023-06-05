import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-move-robo-',
  templateUrl: './move-robo.component.html'
})

export class MoveRoboComponent {

  public link: string = ""
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.link = baseUrl + 'swagger';

  }

}
