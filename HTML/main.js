/**
 * enchant();
 * Preparation for using enchant.js.
 * (Exporting enchant.js class to global namespace.
 *  ex. enchant.Sprite -> Sprite etc..)
 *
 * enchant.js を使う前に必要な処理。
 * (enchant.js 本体や、読み込んだプラグインの中で定義されている enchant.Foo, enchant.Plugin.Bar などのクラスを、
 *  それぞれグローバルの Foo, Bar にエクスポートする。)
 */
enchant();

var bgLPath = "Resources/Textures/UI/BG/SGJ_background_L_02.png";
var bgRPath = "Resources/Textures/UI/BG/SGJ_background_R_02.png";
var robotWork = "Resources/Textures/Character/robot_walk_s.png";
var dragButton = "Resources/Textures/UI/Buttons/B_Active.png";
var dragFrame = "Resources/Textures/png/line.png";
var bgmPath = "Resources/Sounds/SE/Robot_Walk_02.wav";

var frames = [];

/*
 * window.onload
 *
 * The function which will be executed after loading page.
 * Command in enchant.js such as "new Core();" will cause an error if executed before entire page is loaded.
 *
 * ページがロードされた際に実行される関数。
 * すべての処理はページがロードされてから行うため、 window.onload の中で実行する。
 * 特に new Core(); は、<body> タグが存在しないとエラーになるので注意。
 */
window.onload = function(){
    /**
     * new Core(width, height)
     *
     * Make instance of enchant.Core class. Set window size to 320 x 320
     * Core オブジェクトを作成する。
     * 画面の大きさは 320ピクセル x 320ピクセル に設定する。
     */
    var game = new Core(960, 540);

    // バナナを増やす関数 (6フレームごとに呼ばれる)
    var addFrame = function(before){
      console.log(before);
      var newFrame = new Sprite(100, 100);    // Spriteを生成
      newFrame.x = 100;
      newFrame.y = before.y + 150;
      newFrame.image = game.assets[dragFrame];
      game.rootScene.addChild(newFrame);
      frames.push(newFrame);
//      currentFrame = newFrame;
//      console.log(currentFrame);
    };

    /**
     * Core.fps
     *
     * Set fps (frame per second) in this game to 15.
     * ゲームの fps (frame per second) を指定する。この場合、1秒間あたり15回画面が更新される。
     */
    game.fps = 30;
    /**
     * Core#preload
     *
     * You can preload all assets files before starting the game.
     * Set needed file lists in relative/absolute path for attributes of Core#preload
     * 必要なファイルを相対パスで引数に指定する。 ファイルはすべて、ゲームが始まる前にロードされる。
     */

    game.preload([
        bgLPath,
        bgRPath,
        robotWork,
        dragButton,
        bgmPath,
        dragFrame]);

    /**
     * Core#onload
     *
     * ロードが完了した直後に実行される関数を指定している。
     * onload プロパティは load イベントのリスナとして働くので、以下の2つの書き方は同じ意味。
     *
     * game.onload = function(){
     *     // code
     * }
     *
     * game.addEventListener("load", function(){
     *     // code
     * })
     */
    game.onload = function(){
        /**
         * new Sprite(width, height)
         * スプライトオブジェクトを作成する。
         * Sprite は、Entity, Node, EventTarget を継承しており、それぞれのメソッドやプロパティを使うことができる。
         */
        bear = new Sprite(32, 32);

        /**
         * Sprite.image {Object}
         * Core#preload で指定されたファイルは、Core.assets のプロパティとして格納される。
         * Sprite.image にこれを代入することで、画像を表示することができる
         */
        backgroundR = new Sprite(640, 540);
        backgroundR.x = 320;
        backgroundR.y = 0;    // Sprite の左上の x, y 座標を指定
        backgroundR.image = game.assets[bgRPath];

        backgroundL = new Sprite(320, 540);
        backgroundL.x = 0;
        backgroundL.y = 0;    // Sprite の左上の x, y 座標を指定
        backgroundL.image = game.assets[bgLPath];

        bt = new Sprite(100, 100);
        bt.x = 25;
        bt.y = 25;    // Sprite の左上の x, y 座標を指定
        bt.image = game.assets[dragButton];

        bgm = game.assets[bgmPath];
        game.rootScene.addEventListener("enterframe", function(){
          bgm.play();
        });

        /**
         * Node.x Node.y {Number}
         * x, y 座標を指定する。
         * viewport の大きさに合わせて画面が拡大縮小されている場合も、
         * オリジナルの座標系で指定できる。
         */
        bear.x = 0;
        bear.y = 0;

        /**
         * Sprite.frame {Number}
         * (width, height) ピクセルの格子で指定された画像を区切り、
         * 左上から数えて frame 番目の画像を表示することができる。
         * デフォルトでは、0:左上の画像が表示される。
         * このサンプルでは、シロクマが立っている画像を表示する (chara1.gif 参照)。
         */
        bear.frame = 5;

        robot = new Sprite(150, 200);

        /**
         * Sprite.image {Object}
         * Core#preload で指定されたファイルは、Core.assets のプロパティとして格納される。
         * Sprite.image にこれを代入することで、画像を表示することができる
         */
        robot.image = game.assets[robotWork];
        robot.x = 350;
        robot.y = 150;
        /**
         * Sprite.frame {Number}
         * (width, height) ピクセルの格子で指定された画像を区切り、
         * 左上から数えて frame 番目の画像を表示することができる。
         * デフォルトでは、0:左上の画像が表示される。
         * このサンプルでは、シロクマが立っている画像を表示する (chara1.gif 参照)。
         */

         var firstFrame = new Sprite(100, 100);    // Spriteを生成
         firstFrame.x = 100;
         firstFrame.y = 150;
         firstFrame.image = game.assets[dragFrame];
         frames.push(firstFrame);

        
        /**
         * Group#addChild(node) {Function}
         * オブジェクトをノードツリーに追加するメソッド。
         * ここでは、クマの画像を表示するスプライトオブジェクトを、rootScene に追加している。
         * Core.rootScene は Group を継承した Scene クラスのインスタンスで、描画ツリーのルートになる特別な Scene オブジェクト。
         * この rootScene に描画したいオブジェクトを子として追加する (addChild) ことで、毎フレーム描画されるようになる。
         * 引数には enchant.Node を継承したクラス (Entity, Group, Scene, Label, Sprite..) を指定する。
         */
        game.rootScene.addChild(backgroundL);
        game.rootScene.addChild(bt);
        game.rootScene.addChild(backgroundR);
        game.rootScene.addChild(robot);
        game.rootScene.addChild(firstFrame);

        /**
         * EventTarget#addEventListener(event, listener)
         * イベントに対するリスナを登録する。
         * リスナとして登録された関数は、指定されたイベントの発行時に実行される。
         * よく使うイベントには、以下のようなものがある。
         * - "touchstart" : タッチ/クリックされたとき
         * - "touchmove" : タッチ座標が動いた/ドラッグされたとき
         * - "touchend" : タッチ/クリックが離されたとき
         * - "enterframe" : 新しいフレームが描画される前
         * - "exitframe" : 新しいフレームが描画された後
         * enchant.js やプラグインに組み込まれたイベントは、それぞれのタイミングで自動で発行されるが、
         * EventTarget#dispatchEvent で任意のイベントを発行することもできる。
         *
         * ここでは、右に向かって走っていくアニメーションを表現するために、
         * 新しいフレームが描画される前に、毎回クマの画像を切り替え、x座標を1増やすという処理をリスナとして追加する。
         */

        robot.addEventListener("enterframe", function(){
            this.frame = (this.age / 4) % 8 + 1;
        });

        /**
         * タッチされると消える処理を実現するために、
         * touchstart イベントが起こったとき、クマが消える処理をリスナとして追加する。
         */
        bear.addEventListener("touchstart", function(){
            /**
             * クマを game.rootScene から削除する。
             * Group#addChild の逆は Group#removeChild。
             */
            game.rootScene.removeChild(bear);
        });

        // タッチしたときに移動させる
        game.rootScene.addEventListener('touchstart', function(e){
            bt.x = e.localX
            bt.y = e.localY
        });

        // タッチ座標が動いたときに移動させる
        game.rootScene.addEventListener('touchmove', function(e){
            bt.x = e.localX - bt.width / 2;
            bt.y = e.localY - bt.height / 2;
        });
        // タッチ座標が動いたときに移動させる
        game.rootScene.addEventListener('touchend', function(e){
            bt.x = 25;
            bt.y = 25;
            var currentFrame = frames[frames.length - 1];
            if(currentFrame.x <= e.localX && e.localX <= (currentFrame.x + currentFrame.width) && (currentFrame.y <= e.localY && e.localY <= currentFrame.y + currentFrame.height)){
               addFrame(currentFrame);
            }
        });
    };

    /**
     * Core#start
     * ゲームを開始する。この関数を実行するまで、ゲームは待機状態となる。
     * 代わりに Core#debug を使うことで、デバッグモードで起動することができる。
     * Core#pause(); で一時停止し、 Core#resume(); で再開することができる。
     */
    game.start();
};
