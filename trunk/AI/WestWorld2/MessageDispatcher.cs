namespace WestWorld2 {
    using System;

    public class MessageDispatcher {
        private static readonly Lazy<MessageDispatcher> Lazy = new Lazy<MessageDispatcher>(()=>new MessageDispatcher());
        private MessageDispatcher() { }
        public static MessageDispatcher Instance { get { return Lazy.Value; } }

        private readonly PriorityQueue<Telegram> _priorityQueue = new PriorityQueue<Telegram>();

        public void DispatchMessage(double delay, BaseGameEntity sender, BaseGameEntity receiver, MessageType msg, object extraInfo) {

            var telegram = new Telegram {
                DispatchTime = 0,
                Sender = sender.Id,
                Receiver = receiver.Id,
                MessageType = msg,
                ExtraData = extraInfo
            };
            if (delay <= 0) {
                LogTelegram("Instant telegram dispatched at time: {0} by {1} to {2}. Msg is {3}", Clock.GlobalClock.GetCurrentTime(), sender.Name, receiver.Name, msg);
                Discharge(receiver, telegram);
            } else {
                telegram.DispatchTime = Clock.GlobalClock.GetCurrentTime() + delay;
                _priorityQueue.Enqueue(telegram.DispatchTime, telegram);
                LogTelegram("Delayed telegram from {0} recorded at time {1} for {2}. Msg is {3}", sender.Name, Clock.GlobalClock.GetCurrentTime(), receiver.Name, msg);
            }
        }

        public void DispatchDelayedMessages() {
            while (!_priorityQueue.IsEmpty && _priorityQueue.Peek().DispatchTime <= Clock.GlobalClock.GetCurrentTime()) {
                var telegram = _priorityQueue.Dequeue();
                var receiver = EntityManager.Instance[telegram.Receiver];
                LogTelegram("Queued telegram ready for dispatch: Sent to {0}. Msg is {1}", receiver.Name, telegram.MessageType);
                Discharge(receiver, telegram);
            }
        }

        private static void Discharge(BaseGameEntity receiver, Telegram t) {
            if (!receiver.HandleMessage(t)) {
                LogTelegram("Message for {0} not handled", receiver.Name);
            }
        }

        private static void LogTelegram(string s, params object[] args) {
            ConsoleUtilities.SetTextColor(ConsoleColor.Black, ConsoleColor.Yellow);
            Console.WriteLine(s, args);
        }

        
    }
}