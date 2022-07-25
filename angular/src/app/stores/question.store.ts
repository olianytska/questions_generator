import { EntityState, EntityStore, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { QuestionModel, QuestionState } from '../models/question.model';

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'questions' })
export class QuestionStore extends EntityStore<QuestionState, QuestionModel> {
  constructor() {
    super();
    this.createUIStore();
  }
}