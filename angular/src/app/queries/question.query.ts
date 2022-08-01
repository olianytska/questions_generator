import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { Observable } from 'rxjs';
import { QuestionModel, QuestionState } from '../models/question.model';
import { QuestionStore } from '../stores/question.store';

@Injectable({ providedIn: 'root' })
export class QuestionQuery extends QueryEntity<QuestionState, QuestionModel> {
  constructor(protected questionStore: QuestionStore) {
    super(questionStore);
    this.createUIQuery();
  }
}