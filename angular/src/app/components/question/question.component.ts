import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { QuestionModel } from 'src/app/models/question.model';
import { QuestionQuery } from 'src/app/queries/question.query';
import { QuestionService } from 'src/app/services/question.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.scss']
})
export class QuestionComponent implements OnInit {
  public questionsList$?: Observable<QuestionModel[]>;
  public question$?: Observable<QuestionModel>;
  public isQuestionShow: boolean = false;
  public isAnswerShow: boolean = false;
  public newItemForm: FormGroup | undefined;

  constructor(private questionQuery: QuestionQuery, private questionService: QuestionService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.formBuilderInit();
    this.questionsList$ = this.questionService.getQuestions();
  }

  public generateQuestion(): void {
    this.isQuestionShow = true;
    this.isAnswerShow = false;
    this.question$ = this.questionService.getRandomQuestion();
  }

  public onShowAnswer(): void {
    this.isAnswerShow = true;
  }

  public onHideAnswer(): void {
    this.isAnswerShow = false;
  }

  public close(): void{
    this.isQuestionShow = false;
  }

  private formBuilderInit(): void {
    this.newItemForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: [''],
      house: [''],
      knownAs: ['']
    });
  }
}
