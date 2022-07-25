import { Injectable } from "@angular/core";
import { QuestionStore } from "../stores/question.store";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { QuestionModel } from "../models/question.model";
import { catchError, Observable, pipe, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { map, tap } from 'rxjs/operators';
import { action } from "@datorama/akita";


@Injectable({
    providedIn: 'root'
})
export class QuestionService {
    constructor(private http: HttpClient, private questionStore: QuestionStore) {}

    getQuestions(): Observable<QuestionModel[]> {
        return this.http
        .get<QuestionModel[]>(environment.apiEndpoint + '/questions')
        .pipe(
          catchError((error: HttpErrorResponse) => {
            alert(error.message);
            return throwError(error.message);
          })
        );
    }

    getRandomQuestion(): Observable<QuestionModel> {
        return this.http
        .get<QuestionModel>(environment.apiEndpoint + '/questions/question')
        .pipe(
          catchError((error: HttpErrorResponse) => {
            alert(error.message);
            return throwError(error.message);
          })
        );
    }
}