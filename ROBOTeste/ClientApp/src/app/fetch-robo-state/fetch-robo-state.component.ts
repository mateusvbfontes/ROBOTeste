import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-robo-state',
  templateUrl: './fetch-robo-state.component.html'
})
export class FetchRoboStateDataComponent {
  public roboResponseModel: RoboResponseModel = {
      isSuccessful: false,
      message: '',
      erros: [],
      data: {
          head: {
              rotationAngle: 0,
              inclination: ''
          },
          leftArm: {
              elbow: '',
              wristRotationAngle: 0
          },
          rightArm: {
              elbow: '',
              wristRotationAngle: 0
          }
      }
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<RoboResponseModel>(baseUrl + 'robo').subscribe(result => {
      this.roboResponseModel = result;
    }, error => console.error(error));
  }
}

interface RoboResponseModel {
  isSuccessful: boolean,
  message: string,
  erros: string[],
  data: {
    head: {
      rotationAngle: number,
      inclination: string
    };
    leftArm: {
      elbow: string,
      wristRotationAngle: number
    };
    rightArm: {
      elbow: string,
      wristRotationAngle: number
    };
  }
}
