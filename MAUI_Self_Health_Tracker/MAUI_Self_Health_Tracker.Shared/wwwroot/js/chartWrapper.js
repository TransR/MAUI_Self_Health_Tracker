window.chartWrapper = {
  charts: {},
  render: function (id, type, data, options) {
    const canvas = document.getElementById(id);
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (this.charts[id]) this.charts[id].destroy();
    this.charts[id] = new Chart(ctx, { type, data, options: options || {} });
  },
  update: function (id, data, options) {
    const c = this.charts[id];
    if (!c) return;
    c.config.data = data;
    if (options) c.config.options = options;
    c.update();
  }
};
