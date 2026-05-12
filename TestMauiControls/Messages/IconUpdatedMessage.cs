using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TestMauiControls.Messages;

internal class IconUpdatedMessage(bool hasChanged) : ValueChangedMessage<bool>(hasChanged);