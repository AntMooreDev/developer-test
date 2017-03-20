var MyOffers = React.createClass({
    getInitialState: function () {
        return { data: this.props.initialData }
    },
    fetchNotifications: function () {
        var self = this;

        // Get notifications from the server
        Bardic.ajax({
            includeDebugData: false,
            type: 'POST',
            url: '/Notifications/GetAllOffersNotificationsCountForCurrentUser',
            onSuccess: function (JsonData) {
                self.setState(function (prevState, props) {
                    var stateData = prevState.data;
                    stateData.NotificationCount = JsonData.NotificationCount;

                    return {
                        data: stateData
                    };
                });
            }
        })
    },
    componentDidMount: function() {
        window.setInterval(this.fetchNotifications, 2000);
    },
    render: function () {
        return (
            <a href={this.state.data.Url} title={this.state.data.NotificationCount ? (this.state.data.NotificationCount + " new update(s)") : (null)}>
                {this.state.data.Text} {this.state.data.NotificationCount ? (<span className="badge">{this.state.data.NotificationCount}</span>) : ("")}
            </a>
        );
    }
});