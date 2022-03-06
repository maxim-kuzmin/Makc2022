export class MessageService {
  messages: string[] = [];

  private subscriptionId = 0;

  private subscriptions: { [id: string]: (messages: string[]) => void } = {};

  subscribe(handler: (messages: string[]) => void): string {
    this.subscriptionId += 1;
    const subscriptionId = this.subscriptionId.toString();
    this.subscriptions[subscriptionId] = handler;
    return subscriptionId;
  }

  unsubscribe(id: string): void {
    delete this.subscriptions[id];
  }

  add(message: string): void {
    this.messages.push(message);
    this.refresh();
  }

  clear(): void {
    this.messages = [];
    this.refresh();
  }

  private refresh(): void {
    Object.keys(this.subscriptions).forEach((id) => {
      this.subscriptions[id]([...this.messages]);
    });
  }
}
