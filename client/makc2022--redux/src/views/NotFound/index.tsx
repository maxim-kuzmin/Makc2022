import React from 'react';
import { useTranslation } from 'react-i18next';

export function NotFound(): React.ReactElement {
  const { t } = useTranslation(['views/NotFound']);

  return (
    <>
      <h2>{t('title')}</h2>
      <div />
    </>
  );
}
