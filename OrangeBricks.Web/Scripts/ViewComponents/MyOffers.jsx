var MyOffers = React.createClass({
    getInitialState: function () {
        return { data: this.props.initialData }
    },
    fetchNotifications: function() {
        // Get notifications from the server
    },
    componentDidMount: function() {
        window.setInterval(this.fetchNotifications, 30000);
    },
    render: function () {
        return (
            <a href={this.state.data.Url}>{this.state.data.Text}</a>
        );
    }
});