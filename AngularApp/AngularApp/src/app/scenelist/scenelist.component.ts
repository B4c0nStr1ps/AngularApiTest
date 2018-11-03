import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-scenelist',
  templateUrl: './scenelist.component.html',
  styleUrls: ['./scenelist.component.css']
})
export class ScenelistComponent implements OnInit {

  constructor(private http: HttpClient) { }
  values: string;
  scenes: any;

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    let responseText: string;
    this.http.get('http://localhost:50672/api/values', {responseType: 'text'}).subscribe(response => {
      responseText = response;
      this.values = response;
      const parser = new DOMParser();
      const xmlDoc = parser.parseFromString(responseText, 'application/xml');
      const sceneList = xmlDoc.getElementsByTagName('Scene');
      const obj = [];
      let i: number;
      for (i = 0; i < sceneList.length; ++i) {
        const sceneObj = { 'name': sceneList[i].getAttribute('name') };
        obj.push(sceneObj);
      }
      this.scenes = obj;

    }, error => {
      console.log(error);
    });
  }

}
