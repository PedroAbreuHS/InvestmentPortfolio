"use strict";
var __esDecorate = (this && this.__esDecorate) || function (ctor, descriptorIn, decorators, contextIn, initializers, extraInitializers) {
    function accept(f) { if (f !== void 0 && typeof f !== "function") throw new TypeError("Function expected"); return f; }
    var kind = contextIn.kind, key = kind === "getter" ? "get" : kind === "setter" ? "set" : "value";
    var target = !descriptorIn && ctor ? contextIn["static"] ? ctor : ctor.prototype : null;
    var descriptor = descriptorIn || (target ? Object.getOwnPropertyDescriptor(target, contextIn.name) : {});
    var _, done = false;
    for (var i = decorators.length - 1; i >= 0; i--) {
        var context = {};
        for (var p in contextIn) context[p] = p === "access" ? {} : contextIn[p];
        for (var p in contextIn.access) context.access[p] = contextIn.access[p];
        context.addInitializer = function (f) { if (done) throw new TypeError("Cannot add initializers after decoration has completed"); extraInitializers.push(accept(f || null)); };
        var result = (0, decorators[i])(kind === "accessor" ? { get: descriptor.get, set: descriptor.set } : descriptor[key], context);
        if (kind === "accessor") {
            if (result === void 0) continue;
            if (result === null || typeof result !== "object") throw new TypeError("Object expected");
            if (_ = accept(result.get)) descriptor.get = _;
            if (_ = accept(result.set)) descriptor.set = _;
            if (_ = accept(result.init)) initializers.unshift(_);
        }
        else if (_ = accept(result)) {
            if (kind === "field") initializers.unshift(_);
            else descriptor[key] = _;
        }
    }
    if (target) Object.defineProperty(target, contextIn.name, descriptor);
    done = true;
};
var __runInitializers = (this && this.__runInitializers) || function (thisArg, initializers, value) {
    var useValue = arguments.length > 2;
    for (var i = 0; i < initializers.length; i++) {
        value = useValue ? initializers[i].call(thisArg, value) : initializers[i].call(thisArg);
    }
    return useValue ? value : void 0;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var __setFunctionName = (this && this.__setFunctionName) || function (f, name, prefix) {
    if (typeof name === "symbol") name = name.description ? "[".concat(name.description, "]") : "";
    return Object.defineProperty(f, "name", { configurable: true, value: prefix ? "".concat(prefix, " ", name) : name });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.PortfolioComponent = void 0;
var core_1 = require("@angular/core");
var PortfolioComponent = function () {
    var _classDecorators = [(0, core_1.Component)({
            selector: 'app-portfolio',
            templateUrl: './portfolio.component.html',
            styleUrls: ['./portfolio.component.css']
        })];
    var _classDescriptor;
    var _classExtraInitializers = [];
    var _classThis;
    var PortfolioComponent = _classThis = /** @class */ (function () {
        function PortfolioComponent_1(portfolioDataService, router) {
            this.portfolioDataService = portfolioDataService;
            this.router = router;
            this.portfolios = [];
            this.portfolio = {};
            this.userLogin = {};
            this.userLogged = {};
            this.showList = false;
            this.isAuthenticated = false;
        }
        PortfolioComponent_1.prototype.ngOnInit = function () {
            this.getUserData();
            this.get();
        };
        PortfolioComponent_1.prototype.get = function () {
            return __awaiter(this, void 0, void 0, function () {
                var _this = this;
                return __generator(this, function (_a) {
                    return [2 /*return*/, new Promise(function (resolve, reject) {
                            _this.portfolioDataService.get().subscribe(function (res) {
                                console.log('Resposta do serviço:', res);
                                console.log('Tipo de res:', Array.isArray(res) ? 'Array' : 'Objeto');
                                _this.portfolios = Array.isArray(res) ? res : Object.values(res);
                            }, function (error) {
                                console.log(error);
                                alert('erro interno do sistema');
                                reject();
                            });
                        })];
                });
            });
        };
        PortfolioComponent_1.prototype.save = function () {
            if (this.portfolio.id) {
                this.put();
            }
            else {
                this.post();
            }
        };
        PortfolioComponent_1.prototype.openDetails = function (portfolio) {
            this.showList = false;
            this.portfolio = portfolio;
        };
        PortfolioComponent_1.prototype.post = function () {
            var _this = this;
            this.portfolioDataService.post(this.portfolio).subscribe(function (data) { return __awaiter(_this, void 0, void 0, function () {
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            if (!data) return [3 /*break*/, 2];
                            alert('Portfólio cadastrado com sucesso');
                            return [4 /*yield*/, this.get()];
                        case 1:
                            _a.sent();
                            this.portfolio = {};
                            this.getUserData();
                            if (this.portfolios.length >= 1)
                                this.showList = true;
                            return [3 /*break*/, 3];
                        case 2:
                            alert('Erro ao cadastrar Portfólio:');
                            _a.label = 3;
                        case 3: return [2 /*return*/];
                    }
                });
            }); }, function (error) {
                console.log(error);
                alert('Erro interno do sistema:' + error.error);
            });
        };
        PortfolioComponent_1.prototype.put = function () {
            var _this = this;
            this.portfolioDataService.put(this.portfolio).subscribe(function (data) {
                if (data) {
                    alert('Portfólio atualizado com sucesso');
                    _this.get();
                    _this.portfolio = {};
                    _this.getUserData();
                }
                else {
                    alert('Erro ao atualizar Portfólio');
                }
            }, function (error) {
                console.log(error);
                alert('erro interno do sistema');
            });
        };
        PortfolioComponent_1.prototype.delete = function () {
            var _this = this;
            this.portfolioDataService.delete().subscribe(function (data) {
                if (data) {
                    alert('Portfólio excluído com sucesso');
                    _this.get();
                    _this.portfolio = {};
                    _this.getUserData();
                }
                else {
                    alert('Erro ao excluir Portfólio');
                }
            }, function (error) {
                console.log(error);
                alert('erro interno do sistema');
            });
        };
        PortfolioComponent_1.prototype.getUserData = function () {
            this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
            this.isAuthenticated = this.userLogged != null;
            this.portfolio.usuario = {
                nome: this.userLogged.nome,
                senha: this.userLogged.senha,
                email: this.userLogged.email,
                confirmarsenha: ''
            };
            this.portfolio.usuarioId = this.userLogged.id;
        };
        return PortfolioComponent_1;
    }());
    __setFunctionName(_classThis, "PortfolioComponent");
    (function () {
        var _metadata = typeof Symbol === "function" && Symbol.metadata ? Object.create(null) : void 0;
        __esDecorate(null, _classDescriptor = { value: _classThis }, _classDecorators, { kind: "class", name: _classThis.name, metadata: _metadata }, null, _classExtraInitializers);
        PortfolioComponent = _classThis = _classDescriptor.value;
        if (_metadata) Object.defineProperty(_classThis, Symbol.metadata, { enumerable: true, configurable: true, writable: true, value: _metadata });
        __runInitializers(_classThis, _classExtraInitializers);
    })();
    return PortfolioComponent = _classThis;
}();
exports.PortfolioComponent = PortfolioComponent;
//# sourceMappingURL=portfolio.component.js.map