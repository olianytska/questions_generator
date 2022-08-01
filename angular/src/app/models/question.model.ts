import { EntityState, ID } from "@datorama/akita"

export type QuestionModel = {
    questionId: ID,
    title: string,
    answer: string
}

export interface QuestionState extends EntityState<QuestionModel> {}
