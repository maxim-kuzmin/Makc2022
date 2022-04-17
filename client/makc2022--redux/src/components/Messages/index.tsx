import React, { useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { useModuleContext } from '../../contexts';
import styles from './Messages.module.css';
import { clear, selectMessages, setMessages } from './messagesSlice';

export function Messages(): React.ReactElement | null {
  const { messageService } = useModuleContext();

  const { t } = useTranslation(['components/Messages']);

  const messages = useAppSelector(selectMessages);

  const dispatch = useAppDispatch();

  useEffect(() => {
    const subscriptionId = messageService.subscribe((messagesValue) => {
      dispatch(setMessages(messagesValue));
    });
    return () => {
      messageService.unsubscribe(subscriptionId);
      dispatch(clear());
    };
  }, [dispatch, messageService]);

  if (!messages.length) {
    return null;
  }

  return (
    <div className={styles.messages}>
      <h2>{t('@@title')}</h2>
      <button
        type='button'
        className={styles.clear}
        onClick={() => messageService.clear()}
      >
        {t('@@action-clear-messages')}
      </button>
      {messages.map((message, index) => (
        <div key={index}>{message}</div>
      ))}
    </div>
  );
}
