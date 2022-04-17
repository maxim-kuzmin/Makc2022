import { getMessagesSuccess } from './../messages/messages.slice';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { MessageService } from '../../services/message.service';
import { clear, selectMessages } from './messages.slice';
import { I18NEXT_NAMESPACE } from 'angular-i18next';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css'],
  providers: [
    {
      provide: I18NEXT_NAMESPACE,
      useValue: 'components/messages',
    },
  ],
})
export class MessagesComponent implements OnDestroy, OnInit {
  messages$ = this.store.select(selectMessages);
  messagesLength = 0;
  subscriptionId = '';

  constructor(public messageService: MessageService, private store: Store) {
    this.messages$.subscribe((messages) => {
      this.messagesLength = messages.length;
    });
  }

  clearMessages(): void {
    this.messageService.clear();
    this.store.dispatch(clear());
  }

  ngOnDestroy(): void {
    this.messageService.unsubscribe(this.subscriptionId);
    this.store.dispatch(clear());
  }

  ngOnInit(): void {
    this.subscriptionId = this.messageService.subscribe((messages) => {
      this.store.dispatch(getMessagesSuccess({ messages }));
    });
  }
}
